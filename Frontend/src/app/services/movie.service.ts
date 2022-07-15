import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ListResponseModel } from '../models/listResponseModel';
import { Movie } from '../models/movie';
import { ResponseModel } from '../models/responseModel';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  apiUrl="https://localhost:7171/api/"

  constructor(private httpClient:HttpClient) { }
   
  getMovies():Observable<ListResponseModel<Movie>>{
    let newPath=this.apiUrl+"Movies/getall";
    return this.httpClient.get<ListResponseModel<Movie>>(newPath);
  }
  getMoviesByCategory(categoryId:number):Observable<ListResponseModel<Movie>>{
    let newPath=this.apiUrl+"Movies/getbycategory?categoryId="+categoryId;
    return this.httpClient.get<ListResponseModel<Movie>>(newPath);
  }
  add(movie:Movie):Observable<ResponseModel>{
    return this.httpClient.post<ResponseModel>(this.apiUrl+"movies/add",movie);
  }
}
