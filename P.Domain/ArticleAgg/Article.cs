﻿using _01_Framework.Domain;
using P.Domain.ArticleCategoryAgg;
using P.Domain.CommentAgg;
using P.Domain.Services.ArticleServices;

namespace P.Domain.ArticleAgg;

public class Article : BaseModel<long>
{
    public Article(IArticleValidatorServices articleValidator, string title, string shortDescription, string image,
        long articleCategoryId, string content = "")
    {
        Title = title;
        ShortDescription = shortDescription;
        Image = image;
        Content = content;
        ArticleCategoryId = articleCategoryId;
        IsDeleted = false;
    }

    protected Article()
    {
    }

    public string Title { get; private set; }
    public string ShortDescription { get; private set; }
    public string Image { get; private set; }
    public string Content { get; private set; }

    public bool IsDeleted { get; private set; }
    public long ArticleCategoryId { get; private set; }
    public ArticleCategory ArticleCategory { get; private set; }
    public IList<Comment> Comments { get; private set; }

    public void Update(IArticleValidatorServices articleValidator, string title, string shortDescription, string image,
        long articleCategoryId,
        string content = "")
    {
        Title = title;
        ShortDescription = shortDescription;
        Image = image;
        Content = content;
        ArticleCategoryId = articleCategoryId;
        Comments = new List<Comment>();
    }

    public void ChangeState(bool state)
    {
        IsDeleted = state;
    }
}