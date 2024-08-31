import { Component } from '@angular/core';
import {NgForm} from '@angular/forms'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'BlogForm';
  userData:any={};
  show=true;

  Toggle()
  {
    this.show=!this.show;
  }

  GetData(data:NgForm)
  {
    console.log(data);
     this.userData=data
  }
}
