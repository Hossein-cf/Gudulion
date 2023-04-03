using Gudulion.BackEnd.Moduls.Sweet.Model;

namespace Gudulion.BackEnd.Moduls.Sweet.DTO;

public class SweetChangeStatusDto
{
    public int Id { get; set; }
    public SweetStatus OldStatus { get; set; }
    public SweetStatus NewStatus { get; set; }
}

public class SweetSurveyDto
{
    public int UserId { get; set; }
    public int SweetId { get; set; }
    public SweetAcceptance Acceptance { get; set; }
}

public class SweetUserMappingDto : SweetSurveyDto
{
    public bool IsPayer { get; set; }
}