using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Мебель
{
    public class StringOfNumberAttribute : ValidationAttribute
    {
        public int MinLenght { get; set; } = 0;
        public int MaxLenght { get; set; } = int.MaxValue;

        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string str = value as string;
                if (str.Length < this.MinLenght)
                {
                    this.ErrorMessage = "Строка не может быть меньше " + this.MinLenght + " символов.";
                    return false;
                }
                else if (str.Length > this.MaxLenght)
                {
                    this.ErrorMessage = "Строка не может превышать " + this.MaxLenght + " символов.";
                    return false;
                }

                for (int i = 0; i < str.Length; i++)
                    if (!char.IsDigit(str[i]))
                    {
                        this.ErrorMessage = "Строка может содержать только цифры.";
                        return false;
                    }

                return true;
            }

            return true;
        }
    }
}
