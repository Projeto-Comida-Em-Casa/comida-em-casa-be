using System.ComponentModel;

namespace ComidaEmCasa.Core.Exceptions
{
    public enum ExceptionTags
    {
        [Description("entity not found")]
        ENTITY_NOT_FOUND = 1,
        [Description("Email already exists")]
        EMAIL_ALREADY_EXISTS = 2,
        [Description("CPF already exists")]
        CPF_ALREADY_EXISTS = 3,
        [Description("Invalid email or password")]
        INVALID_EMAIL_OR_PASSWORD = 4
    }
}
