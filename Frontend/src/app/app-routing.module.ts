import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { MovieAddComponent } from './components/movie-add/movie-add.component';
import { MovieComponent } from './components/movie/movie.component';
import { SessionComponent } from './components/session/session.component';
import { LoginGuard } from './guards/login.guard';

const routes: Routes = [
  {path:"",pathMatch:"full",component:SessionComponent},
  {path:"sessions",component:SessionComponent},
  {path:"movies",component:MovieComponent},
  {path:"movies/category/:categoryId",component:MovieComponent},
  {path:"movies/add",component:MovieAddComponent,canActivate:[LoginGuard]},
  {path:"login",component:LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
