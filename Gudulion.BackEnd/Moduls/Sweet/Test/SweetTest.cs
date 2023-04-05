using Gudulion.BackEnd.Moduls.Sweet.DTO;
using Gudulion.BackEnd.Moduls.Sweet.Model;
using Gudulion.BackEnd.Test;
using NUnit.Framework;

namespace Gudulion.BackEnd.Test;
[TestFixture,Order(4)]
public class SweetTest:TestGeneric
{
    [Test, Order(1)]
    public void AddUserToSweet()
    {
        var dtos = new List<SweetUserMappingDto>()
        {
            new SweetUserMappingDto
            {
                UserId = 1,
                Acceptance = SweetAcceptance.Pending,
                SweetId = 1,
            },
            new SweetUserMappingDto
            {
                UserId = 2,
                Acceptance = SweetAcceptance.Pending,
                SweetId = 1,
            },
            new SweetUserMappingDto
            {
                UserId = 3,
                Acceptance = SweetAcceptance.Pending,
                SweetId = 1,
            },
            new SweetUserMappingDto
            {
                UserId = 4,
                Acceptance = SweetAcceptance.Pending,
                SweetId = 1,
            },
        };
        _sweetService?.AddUserToSweet(dtos);
    }

    [Test, Order(2)]
    public void SurveyToSweet()
    {
        var dto = new SweetSurveyDto
        {
            UserId = 1,
            SweetId = 1,
            Acceptance = SweetAcceptance.Accepted,
        };
        _sweetService?.Survey(dto);
        var dto1 = new SweetSurveyDto
        {
            UserId = 3,
            SweetId = 1,
            Acceptance = SweetAcceptance.Rejected,
        };
        _sweetService?.Survey(dto1);
    }

    [Test, Order(3)]
    public void ChangeSweetStatus()
    {
        var dto = new SweetChangeStatusDto
        {
            Id = 1,
            NewStatus = SweetStatus.Payed,
        };
        _sweetService?.ChangeStatus(dto);
    }
    
}