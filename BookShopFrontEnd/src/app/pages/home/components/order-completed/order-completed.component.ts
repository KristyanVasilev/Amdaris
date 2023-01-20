import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-order-completed',
  templateUrl: './order-completed.component.html',
  styleUrls: ['./order-completed.component.css']
})
export class OrderCompletedComponent {

  constructor(private router: Router){}
  
  home(){
    this.router.navigate(['home'])
  }
}
