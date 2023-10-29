using System.Collections.Generic;
using CommentManagement.Application.Contracts.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Comments;

public class IndexModel : PageModel
{
    private readonly ICommentApplication _commentApplication;
    public List<CommentViewModel> Comments;
    public CommentSearchModel SearchModel;

    public IndexModel(ICommentApplication commentApplication)
    {
        _commentApplication = commentApplication;
    }

    [TempData] public string Message { get; set; }

    public void OnGet(CommentSearchModel searchModel)
    {
        Comments = _commentApplication.Search(searchModel);
    }

    public IActionResult OnGetCancel(long id)
    {
        var result = _commentApplication.Cancel(id);
        if (result.IsSuccedded)
            return RedirectToPage("./Index");

        Message = result.Message;
        return RedirectToPage("./Index");
    }

    public IActionResult OnGetConfirm(long id)
    {
        var result = _commentApplication.Confirm(id);
        if (result.IsSuccedded)
            return RedirectToPage("./Index");

        Message = result.Message;
        return RedirectToPage("./Index");
    }
}