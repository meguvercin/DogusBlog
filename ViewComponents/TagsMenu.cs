using DogusBlog.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DogusBlog.ViewComponents{

    public class TagsMenu:ViewComponent{

        private ITagRepository _tagRepository;

        public TagsMenu(ITagRepository tagRepository){
            _tagRepository = tagRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(){
            return View(await _tagRepository.Tags.ToListAsync());
        }
    }
}