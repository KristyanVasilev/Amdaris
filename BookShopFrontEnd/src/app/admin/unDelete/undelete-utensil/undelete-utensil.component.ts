import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, Subscription, throwError } from 'rxjs';
import { Utensil } from 'src/app/models/utensil';
import { UtensilService } from 'src/app/services/utensil.service';

@Component({
  selector: 'app-undelete-utensil',
  templateUrl: './undelete-utensil.component.html',
  styleUrls: ['./undelete-utensil.component.css']
})
export class UndeleteUtensilComponent {
  @ViewChild('utensilFindForm') utensilFindForm: any;
  submitted: boolean = false;
  utensilSubsription: Subscription | undefined;
  utensil: Utensil = { id: 0, name: '', price: 0, color: '', writingUtensilsType: '', manufacturer: '', images: [], quantity: 0, keyWords: '' };
  utensilId = {
    id: 0,
  };
  utensilName = {
    name: '',
  };

  constructor(
    private utensilService: UtensilService,
    private router: Router) {

  }

  UndeleteUtensil() {
    this.utensilSubsription = this.utensilService
      .UndeleteUtensil(this.utensilName.name).pipe(
        catchError(error => {
          console.error(error);
          if (error.status == 401 || error.status == 403) {
            this.router.navigate(['home'])
            window.alert('You are unauthorize!')
          }
          return throwError(error);
        }))
      .subscribe((_utensil) => {
        this.utensil = _utensil;
        console.log(_utensil)
        window.alert('Utensil unDeleted successfully!')
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
}
