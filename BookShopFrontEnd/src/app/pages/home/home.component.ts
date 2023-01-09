import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  cols = 3;
  //rowHeight: number = ROWS_HEIGHT[this.cols];

  onColumnsCountChange(colsNum: number): void {
    this.cols = colsNum;
    //this.rowHeight = ROWS_HEIGHT[colsNum];
    console.log(this.cols)
  }

}
