import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'

import { Observable } from 'rxjs';
import { Session } from '../models/session';
import { ListResponseModel } from '../models/listResponseModel';

@Injectable({
  providedIn: 'root'
})
export class SessionService {

  apiUrl="https://localhost:7171/api/Sessions/getall"

  constructor(private httpClient:HttpClient) { }
   
  getSessions():Observable<ListResponseModel<Session>>{

    return this.httpClient.get<ListResponseModel<Session>>(this.apiUrl)
  }
}
