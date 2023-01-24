import { HttpClient } from '@angular/common/http';
import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, Observable, Subscription, throwError } from 'rxjs';
import { Utensil } from 'src/app/models/utensil';
import { UtensilService } from 'src/app/services/utensil.service';

@Component({
  selector: 'app-update-utensil',
  templateUrl: './update-utensil.component.html',
  styleUrls: ['./update-utensil.component.css']
})
export class UpdateUtensilComponent {
  @ViewChild('utensilFindForm') utensilFindForm: any;
  submitted: boolean = false;
  utensilSubsription: Subscription | undefined;
  utensil: Utensil = { id: 0, name: '', price: 0, color: '', writingUtensilsType: '', manufacturer: '', images: [], quantity: 0, keyWords: '' };
  utensilToUpdate: Utensil = { id: 0, name: '', price: 0, color: '', writingUtensilsType: '', manufacturer: '', images: [], quantity: 0, keyWords: '' };
  shortLink: string = "";
  loading: boolean = false; // Flag variable
  isUploaded = false;
  utensilId = {
    id: 0,
  };
  utensilName = {
    name: '',
  };

  constructor(
    private utensilService: UtensilService,
    private router: Router,
    private http: HttpClient,) {
  }

  findUtensil() {
    this.utensilSubsription = this.utensilService
      .findUtensil(this.utensilName.name)
      .subscribe((_utensil) => {
        this.utensil = _utensil;
        console.log(this.utensil)
      });
    this.resetForm();
  }

  resetForm() {
    this.utensilName = { name: "" };
    this.utensil = { id: 0, name: '', price: 0, color: '', writingUtensilsType: '', manufacturer: '', images: [], quantity: 0, keyWords: '' };
    this.utensilFindForm.resetForm();
    this.submitted = false;
  }

  ngOnDestroy(): void {
    if (this.utensilSubsription) {
      this.utensilSubsription.unsubscribe();
    }
  }

  file?: File; // Variable to store file
  upload(file: any): Observable<any> {
    const formData = new FormData();
    formData.append("file", file, file.name);
    this.isUploaded = true;
    return this.http.post('https://localhost:7201/api/Files/Images', formData).pipe(
      catchError(error => {
        console.error(error);
        if (error.status == 401 || error.status == 403) {
          window.alert('You are unauthorize!')
          this.router.navigate(['home'])
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
        this.utensilToUpdate.images.push(JSON.stringify(event).substring(10, JSON.stringify(event).length - 3));
        if (typeof (event) === 'object') {
          this.shortLink = event.link;
          this.loading = false; // Flag variable
        }
      }
    );
  }

  updateUtendils() {
    this.utensilService.UpdateUtensil(this.utensilToUpdate, this.utensil.id).pipe(
      catchError(error => {
        console.error(error);
        if (error.status == 401 || error.status == 403) {
          window.alert('You are unauthorize!')
          this.router.navigate(['home'])
        }
        return throwError(error);
      }))
    .subscribe(res => console.log(res));
    this.router.navigate(['/home']);
  }
}
