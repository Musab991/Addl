namespace AADLBusiness.Permissions
{
    public enum enPermission : int
    {
        Admen = -1,
        AddPractitioner = 1,
        UpdatePractitioner = 2,
        DeletePractitioner = 4,
        ShowPractitionerList = 8,
        AddUser = 16,
        UpdateUser = 32,
        DeleteUser = 64,
        ShowUserList = 128,
    }
}