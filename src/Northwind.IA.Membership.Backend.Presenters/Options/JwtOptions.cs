﻿namespace Northwind.IA.Membership.Backend.Presenters.Options;
public class JwtOptions
{
    public const string SectionKey = nameof(JwtOptions);
    public string SecurityKey { get; set; }
    public string ValidIssuer { get; set; }
    public string ValidAudience { get; set; }
    public int ExpireInMinutes { get; set; }
}
