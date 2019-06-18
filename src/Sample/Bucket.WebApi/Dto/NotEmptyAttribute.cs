﻿using System.ComponentModel.DataAnnotations;

namespace Bucket.WebApi.Dto
{
    /// <summary>
    /// 对象不能为空
    /// </summary>
    public class NotEmptyAttribute : ValidationAttribute
    {
        private string ErrorCode { get; set; }
        public NotEmptyAttribute(string errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }
        private string GetErrorMessage()
        {
            return string.Concat("{", string.Format("\"ErrorCode\":\"{0}\",\"Message\":\"{1}\"", ErrorCode, ErrorMessage), "}");
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var errormsg = GetErrorMessage();
            if (value == null)
                return new ValidationResult(errormsg);
            if (string.IsNullOrWhiteSpace(value.ToString()))
                return new ValidationResult(errormsg);
            return ValidationResult.Success;
        }
    }
}
