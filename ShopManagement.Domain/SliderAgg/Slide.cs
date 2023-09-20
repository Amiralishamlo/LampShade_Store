using _0_Framework.Domain;

namespace ShopManagement.Domain.SliderAgg
{
    public class Slide : EntityBase
    {
        public string Heading { get; private set; }

        public string Title { get; private set; }

        public string Text { get; private set; }

        public string Picture { get; private set; }

        public string PictureAlt { get; private set; }

        public string PictureTitle { get; private set; }

        public string BtnText { get; private set; }

        public bool IsRemove {  get; private set; }

        public Slide(string heading, string title, string text, string picture, string pictureAlt, string pictureTitle, string btnText)
        {
            Heading = heading;
            Title = title;
            Text = text;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            BtnText = btnText;
            IsRemove=false;
        }

        public void Edit(string heading, string title, string text, string picture, string pictureAlt, string pictureTitle, string btnText)
        {
            Heading = heading;
            Title = title;
            Text = text;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            BtnText = btnText;
        }
        public void Remove()
        {
            IsRemove = true;
        }
        public void Restore()
        {
            IsRemove=false;
        }
    }
}
