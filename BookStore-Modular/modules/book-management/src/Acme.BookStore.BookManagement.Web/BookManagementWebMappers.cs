using Acme.BookStore.BookManagement.Authors;
using Acme.BookStore.BookManagement.Books;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;
using AuthorCreateModalModel = Acme.BookStore.BookManagement.Web.Pages.Authors.CreateModalModel;
using AuthorEditModalModel = Acme.BookStore.BookManagement.Web.Pages.Authors.EditModalModel;
using BookCreateModalModel = Acme.BookStore.BookManagement.Web.Pages.Books.CreateModalModel;
using BookEditModalModel = Acme.BookStore.BookManagement.Web.Pages.Books.EditModalModel;

namespace Acme.BookStore.BookManagement.Web
{
    [Mapper]
    public partial class BookDtoToCreateUpdateBookDtoMapper : MapperBase<BookDto, CreateUpdateBookDto>
    {
        public override partial CreateUpdateBookDto Map(BookDto source);
        public override partial void Map(BookDto source, CreateUpdateBookDto destination);
    }

    [Mapper]
    public partial class CreateAuthorViewModelToCreateAuthorDtoMapper
        : MapperBase<AuthorCreateModalModel.CreateAuthorViewModel, CreateAuthorDto>
    {
        public override partial CreateAuthorDto Map(AuthorCreateModalModel.CreateAuthorViewModel source);
        public override partial void Map(AuthorCreateModalModel.CreateAuthorViewModel source, CreateAuthorDto destination);
    }

    [Mapper]
    public partial class AuthorDtoToEditAuthorViewModelMapper
        : MapperBase<AuthorDto, AuthorEditModalModel.EditAuthorViewModel>
    {
        public override partial AuthorEditModalModel.EditAuthorViewModel Map(AuthorDto source);
        public override partial void Map(AuthorDto source, AuthorEditModalModel.EditAuthorViewModel destination);
    }

    [Mapper]
    public partial class EditAuthorViewModelToUpdateAuthorDtoMapper
        : MapperBase<AuthorEditModalModel.EditAuthorViewModel, UpdateAuthorDto>
    {
        public override partial UpdateAuthorDto Map(AuthorEditModalModel.EditAuthorViewModel source);
        public override partial void Map(AuthorEditModalModel.EditAuthorViewModel source, UpdateAuthorDto destination);
    }

    [Mapper]
    public partial class CreateBookViewModelToCreateUpdateBookDtoMapper
        : MapperBase<BookCreateModalModel.CreateBookViewModel, CreateUpdateBookDto>
    {
        public override partial CreateUpdateBookDto Map(BookCreateModalModel.CreateBookViewModel source);
        public override partial void Map(BookCreateModalModel.CreateBookViewModel source, CreateUpdateBookDto destination);
    }

    [Mapper]
    public partial class BookDtoToEditBookViewModelMapper
        : MapperBase<BookDto, BookEditModalModel.EditBookViewModel>
    {
        public override partial BookEditModalModel.EditBookViewModel Map(BookDto source);
        public override partial void Map(BookDto source, BookEditModalModel.EditBookViewModel destination);
    }

    [Mapper]
    public partial class EditBookViewModelToCreateUpdateBookDtoMapper
        : MapperBase<BookEditModalModel.EditBookViewModel, CreateUpdateBookDto>
    {
        public override partial CreateUpdateBookDto Map(BookEditModalModel.EditBookViewModel source);
        public override partial void Map(BookEditModalModel.EditBookViewModel source, CreateUpdateBookDto destination);
    }
}