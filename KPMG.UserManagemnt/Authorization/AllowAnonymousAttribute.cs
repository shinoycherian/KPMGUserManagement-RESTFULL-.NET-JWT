namespace KPMG.UserManagement.Application.Authorization
{
    using Microsoft.AspNetCore.Authorization;
    using System;

    [AttributeUsage(AttributeTargets.Method)]
    public class AllowAnonymousAttribute : Attribute
    { }

}