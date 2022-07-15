import { Timestamp } from "rxjs";

export interface Movie{
    movieId:number;
    employeeId:number;
    movieName:string;
    movieVisionDate:Date;
    movieCategoryId:number;
    movieReview:string;
}