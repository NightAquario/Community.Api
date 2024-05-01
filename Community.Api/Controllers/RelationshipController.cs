using Community.DTO;
using Community.IServices;
using Community.Models;
using Microsoft.AspNetCore.Mvc;

namespace Community.Api.Controllers;

[Controller]
[Route("[controller]")]
public class RelationshipController : Controller
{
    private readonly IRelationshipService _relationshipService;

    public RelationshipController(IRelationshipService relationshipService)
    {
        _relationshipService = relationshipService;
    }

    [HttpGet]
    public async Task<Relationship> GetRelationship(int id) =>
        await _relationshipService.GetRelationship(id);

    [HttpGet]
    public async Task<IEnumerable<Relationship>> GetRelationships() =>
        await _relationshipService.GetRelationships();

    [HttpPost]
    public void AddRelationship(RelationshipModel model)
    {
        if (model == null)
        {
            throw new ArgumentNullException("The provided data was not sufficient");
        }

        Relationship newRelationship = new()
        {
            FromPersonId = model.FromPersonId,
            ToPersonId = model.ToPersonId,
            RelationshipType = (RelationshipType)model.Type
            //needs correction I think
        };
        _relationshipService.AddRelationship(newRelationship);
    }

    [HttpPost]
    public void UpdateRelationship(Relationship model)
    {
        if (model == null)
        {
            throw new ArgumentNullException("The provided data was not sufficient");
        }

        Relationship updatedRelationship = new()
        {
            FromPersonId = model.FromPersonId,
            ToPersonId = model.ToPersonId,
            RelationshipType = model.RelationshipType
        };
        _relationshipService.UpdateRelationship(updatedRelationship);
    }

    [HttpDelete]
    public void DeleteRelationship(int id) =>
        _relationshipService.DeleteRelationship(id);
}
