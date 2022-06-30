using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

MovieManager movieManager = new MovieManager(new EfMovieDal());

foreach (var movie in movieManager.GetAll())
{
   Console.WriteLine(movie.MovieName);
}
