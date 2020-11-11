using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace PedidosD.Shared.Validaciones
{
    public class ValidacionCedula : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string cadena = value as string;

            if (cadena != null)
            {
                string expresion;
                expresion = @"^\d{3}[- ]?\d{7}[- ]?\d{1}$";
                if (Regex.IsMatch(cadena, expresion))
                {
                    if (Regex.Replace(cadena, expresion, String.Empty).Length == 0)
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult("Cédula no válida");
                    }
                }
                else
                    return new ValidationResult("Cédula no válida");
            }
            return new ValidationResult("Debes poner una Cédula");
        }
    }
}
