import { Component, OnInit } from '@angular/core';
import { FormGroup,FormBuilder,FormControl,Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { MovieService } from 'src/app/services/movie.service';

@Component({
  selector: 'app-movie-add',
  templateUrl: './movie-add.component.html',
  styleUrls: ['./movie-add.component.css']
})
export class MovieAddComponent implements OnInit {
  movieAddForm:FormGroup;
  constructor(private formBuilder:FormBuilder,
    private movieService:MovieService,
    private toastrService:ToastrService) { }

  ngOnInit(): void {
    this.createMovieAddForm();
  }
  createMovieAddForm(){
    this.movieAddForm=this.formBuilder.group({
      movieName:["",Validators.required],
      employeeId:["",Validators.required],
      movieVisionDate:["",Validators.required],
      movieCategoryId:["",Validators.required],
      movieReview:["",Validators.required]
    })
  }
  add(){
    if(this.movieAddForm.valid){
      let movieModel=Object.assign({},this.movieAddForm.value);
      
      this.movieService.add(movieModel).subscribe(response=>{
        this.toastrService.success(response.message,"Başarılı");
      },responseError=>{
        if(responseError.error.Errors.length>0){
          for (let index = 0; index < responseError.error.Errors.length; index++) {
            this.toastrService.error(responseError.error.Errors[index].ErrorMessage
              ,"Doğrulama hatası");
            
          }
          
        }
        
      });
      
    }else{
        this.toastrService.error("Formunuz eksik","Dikkat");
    }
    
    
  }
}
