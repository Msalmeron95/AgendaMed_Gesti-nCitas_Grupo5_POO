
using System.Reflection;
using System.Reflection.Metadata;
using

public class InternalUsers
{
    private string? UserName{ get; set; }
    private string? UserPassword{ get; set; }
    private string? UserEmail{ get; set; }
}

public class ExternalUsers
{
    private string? UserName{ get; set; }
    private string? UserPassword{ get; set; }
    private string? UserEmail{ get; set; }

    public ExternalUsers()
    {
        
    }
}