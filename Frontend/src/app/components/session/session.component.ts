import { Component, OnInit } from '@angular/core';
import { Session } from 'src/app/models/session';
import { SessionService } from 'src/app/services/session.service';



@Component({
  selector: 'app-session',
  templateUrl: './session.component.html',
  styleUrls: ['./session.component.css']
})
export class SessionComponent implements OnInit {

  
  sessions:Session[]=[]
  dataLoaded=false;
 
  constructor(private sessionService:SessionService) { }

  ngOnInit(): void {
    this.getSessions();
  }

  getSessions(){
    this.sessionService.getSessions().subscribe(response=>{
      this.sessions=response.data
      this.dataLoaded=true;
    })
      
  }

}
