import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Movie } from 'src/app/models/movie';
import { CartService } from 'src/app/services/cart.service';
import { MovieService } from 'src/app/services/movie.service';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})
export class MovieComponent implements OnInit {
  movies:Movie[]=[];
  dataLoaded=false;
  filterText="";
  
  constructor(private movieService:MovieService,
    private activatedRoute:ActivatedRoute,
    private toastrService:ToastrService,
    private cartService:CartService) { }

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
  addToCart(movie:Movie){
    this.toastrService.success("Sepete eklendi",movie.movieName);
    this.cartService.addToCart(movie);
  }

}
