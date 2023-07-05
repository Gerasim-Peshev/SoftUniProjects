namespace Library.Data
{
    public class DataConstants
    {
        public class Book
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 50;

            public const int AuthorMinLength = 5;
            public const int AuthorMaxLength = 50;

            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 5000;

            public const int RatingMinValue = 0;
            public const int RatingMaxValue = 10;
        }

        public class Category
        {
            public const int NameMinLength = 5;
            public const int NameMaxLenght = 50;
        }
    }
}
