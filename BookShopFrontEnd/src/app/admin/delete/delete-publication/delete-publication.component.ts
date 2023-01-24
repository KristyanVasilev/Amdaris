import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, Subscription, throwError } from 'rxjs';
import { Publication } from 'src/app/models/publication';
import { PublicationService } from 'src/app/services/publication.service';

@Component({
  selector: 'app-delete-publication',
  templateUrl: './delete-publication.component.html',
  styleUrls: ['./delete-publication.component.css']
})
export class DeletePublicationComponent {
  @ViewChild('publicationFindForm') publicationFindForm: any;
  submitted: boolean = false;
  publicationSubsription: Subscription | undefined;
  publication: Publication = { id: 0, name: '', author: '', price: 0, pageCount: 0, description: '', genre: '', images: [], keyWords: '', quantity: 0 };
  publicationId = {
    id: 0,
  };
  publicationName = {
    name: '',
  };

  constructor(
    private publicationService: PublicationService,
    private router: Router) {

  }

  deletePublication() {
    this.publicationSubsription = this.publicationService
      .deletePublication(this.publicationId.id)
      .subscribe((res) => {
        console.log(res),
          window.alert('Publication deleted successfully!')
      });
  }

  FindPublication() {
    this.publicationSubsription = this.publicationService
      .findPublication(this.publicationName.name)
      .subscribe((_publication) => {
        this.publication = _publication;
        console.log(_publication)
      });
    this.resetForm();
  }

  resetForm() {
    this.publicationName = { name: "" };
    this.publication = { id: 0, name: '', author: '', price: 0, pageCount: 0, description: '', genre: '', images: [] as string[], keyWords: '', quantity: 0 };
    this.publicationFindForm.resetForm();
    this.submitted = false;
  }

  ngOnDestroy(): void {
    if (this.publicationSubsription) {
      this.publicationSubsription.unsubscribe();
    }
  }
}
