import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'blog';
  getClick()
  {
    alert("Hello");
  };

  getName(firstName:string,lastName:string)
  {
    alert("Hello " + firstName +" "+ lastName);
  }
 
  displayVal:string='';
  getTextBoxData(textValue:string)
  {
    this.displayVal=textValue;
    console.log(textValue);
  }

name="Diksha";
disable=false;
show="green";
users=['anil','sam','peter']
usersDetails=[
  {name:'anil',email:'anil@gmail.com',SocialAccounts:['fb','insta','twiiter']},
  {name:'sam',email:'sam@gmail.com',SocialAccounts:['youtube','insta','linkedin']},
  {name:'peter',email:'peter@gmail.com',SocialAccounts:['fb','linked','insta']}
]

}
