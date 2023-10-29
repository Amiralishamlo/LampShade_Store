using _0_Framework.Domain;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CommentManagement.Domain.CommentAgg;

public class Comment : EntityBase
{
    public Comment(string name, string email, string website, string message, long ownerRecordId, int type,
        long parentId)
    {
        Name = name;
        Email = email;
        Website = website;
        Message = message;
        OwnerRecordId = ownerRecordId;
        Type = type;
        ParentId = parentId;
    }

    protected Comment()
    {
    }

    public string Name { get; }
    public string Email { get; }
    public string Website { get; }
    public string Message { get; }
    public bool IsConfirmed { get; private set; }
    public bool IsCanceled { get; private set; }
    public long OwnerRecordId { get; }
    public int Type { get; }
    public long ParentId { get; }
    public Comment Parent { get; private set; }

    public void Confirm()
    {
        IsConfirmed = true;
    }

    public void Cancel()
    {
        IsCanceled = true;
    }
}