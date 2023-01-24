import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, Observable, throwError } from 'rxjs';
import { Utensil } from 'src/app/models/utensil';
import { UtensilService } from 'src/app/services/utensil.service';

@Component({
  selector: 'app-create-utensil',
  templateUrl: './create-utensil.component.html',
  styleUrls: ['./create-utensil.component.css']
})
export class CreateUtensilComponent {
  utensil: Utensil = { id: 0, name: '', price: 0, color: '', writingUtensilsType: '', manufacturer: '', images: [] as string[], keyWords: '', quantity: 0 };
  isUploaded = false;

  constructor(
    private http: HttpClient,
    private router: Router,
    private utensilService: UtensilService) { }

  shortLink: string = "";

  loading: boolean = false; // Flag variable

  file?: File; // Variable to store file
  upload(file: any): Observable<any> {
    const formData = new FormData();
    formData.append("file", file, file.name);
    this.isUploaded = true;
    return this.http.post('https://localhost:7201/api/Files/Images', formData).pipe(
      catchError(error => {
        console.error(error);
        if (error.status == 401 || error.status == 403) {
          this.router.navigate(['home'])
          window.alert('You are unauthorize!')
        }
        return throwError(error);
      }))
  }

  onChange(event: any) {

    this.file = event.target.files[0];
  }

  onUpload() {

    this.loading = !this.loading;
    console.log(this.file);

    this.upload(this.file).subscribe(
      (event: any) => {
        console.log(event);
        console.log(JSON.stringify(event).substring(10, JSON.stringify(event).length - 3));
        this.utensil.images.push(JSON.stringify(event).substring(10, JSON.stringify(event).length - 3));
        if (typeof (event) === 'object') {
          this.shortLink = event.link;
          this.loading = false; // Flag variable
        }
      }
    );
  }

  createGame() {
    this.utensilService.createUtensil(this.utensil)
    .pipe(
      catchError(error => {
        console.error(error);
        if (error.status == 401 || error.status == 403) {
          this.router.navigate(['home'])
          window.alert('You are unauthorize!')
        }
        return throwError(error);
      })).subscribe(res => console.log(res));
    this.router.navigate(['home'])
  }
}
