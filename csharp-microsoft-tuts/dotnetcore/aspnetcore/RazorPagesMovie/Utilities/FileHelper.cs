using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Utilities
{

    // Saves file to the database, to save file to disk, use fileStream.
    public class FileHelper
    {
        public static async Task<string> ProcessFormFile(IFormFile formFile, ModelStateDictionary modelState){
            var fieldDisplayName = string.Empty;

            // use reflection to obtain display name for the model property associated with this IformFile. 
            // if a display name isn't found, error messages won't show a name
            MemberInfo property = typeof(FileUpload).GetProperty(formFile.Name.Substring(formFile.Name.IndexOf(".") + 1));

            if(property != null){
                var displayAttr = property.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;

                if(displayAttr != null){
                    fieldDisplayName = $"{displayAttr.Name} ";
                }
            }

            // Get the filename, using HtmlEncoding in case it must be returned in an error.
            var fileName = WebUtility.HtmlEncode(Path.GetFileName(formFile.FileName));

            // Ensure it's a text file
            if(formFile.ContentType.ToLower() != "text/plain"){
                modelState.AddModelError(formFile.Name, $"The {fieldDisplayName}file ({fileName}) must be a text file.");
            }

            // Process the file
            if(formFile.Length == 0){ // Error on empty file
                modelState.AddModelError(formFile.Name, $"The {fieldDisplayName}file({fileName}) is empty.");
            }else if(formFile.Length > 1048576){ // Error on file over 1MB
                modelState.AddModelError(formFile.Name, $"The {fieldDisplayName}file({fileName}) exceeds 1 MB.");
            }else{
                try{
                    string fileContents;

                    // StreamReader is created to read files that are UTF-8 encoded
                    using (var reader = new StreamReader(
                        formFile.OpenReadStream(),
                        new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true), detectEncodingFromByteOrderMarks: true)
                    ){

                        fileContents = await reader.ReadToEndAsync();

                        // check content length incase the files only content was BOM (byte order model)
                        if(fileContents.Length > 0){
                            return fileContents;
                        }else{
                            modelState.AddModelError(formFile.Name, $"The {fieldDisplayName}file({fileName}) is empty.");
                        }

                    }
                
                }catch(Exception ex){

                    modelState.AddModelError(formFile.Name, $"The {fieldDisplayName}file({fileName}) upload failed. Error: {ex.Message}");

                    // log the exception
                }
            }

            return string.Empty;
        }
    }
}
