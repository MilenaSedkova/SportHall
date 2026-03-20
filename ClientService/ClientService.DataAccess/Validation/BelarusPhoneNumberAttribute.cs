using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ClientService.DataAccess.Validation;

public class BelarusPhoneNumberAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if(value is not string phone)
        {
            return false;
        }
        return Regex.IsMatch(phone, @"^+375\d{9}$");
    }
}
