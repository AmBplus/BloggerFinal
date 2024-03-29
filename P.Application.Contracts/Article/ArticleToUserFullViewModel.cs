﻿using P.Application.Contracts.Comment;

namespace P.Application.Contracts.Article;

public class ArticleToUserFullViewModel
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string ArticleCategory { get; set; }
    public string CreationDate { get; set; }
    public string Content { get; set; }
    public string Image { get; set; }
    public IEnumerable<CommentToUserViewModel> CommentsToUser { get; set; }
    public long Count { get; set; }
}