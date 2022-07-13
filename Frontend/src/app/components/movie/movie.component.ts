import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Movie } from 'src/app/models/movie';
import { MovieService } from 'src/app/services/movie.service';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})
export class MovieComponent implements OnInit {
  movies:Movie[]=[];
  dataLoaded=false;
  constructor(private movieService:MovieService,
    private activatedRoute:ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params=>{
      if(params["categoryId"]){
        this.getMoviesByCategory(params["categoryId"]);
      }else{
        this.getMovies();
      }
    })
  }

  getMovies(){
    this.movieService.getMovies().subscribe(response=>{
      this.movies=response.data
      this.dataLoaded=true;
    })   
  }
  getMoviesByCategory(categoryId:number){
    this.movieService.getMoviesByCategory(categoryId).subscribe(response=>{
      this.movies=response.data
      this.dataLoaded=true;
    })   
  }

}
