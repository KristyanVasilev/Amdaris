import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Publication } from 'src/app/models/publication';
import { PublicationService } from 'src/app/services/publication.service';

@Component({
  selector: 'app-undelete-publication',
  templateUrl: './undelete-publication.component.html',
  styleUrls: ['./undelete-publication.component.css']
})
export class UndeletePublicationComponent {
  @ViewChild('UndeletePublicationForm') UndeletePublicationForm: any;
  submitted: boolean = false;
  publicationSubsription: Subscription | undefined;
  publication: Publication = { id: 0, name: '', author: '', price: 0, pageCount: 0, description: '', genre: '', images: [] as string[], keyWords: '', quantity: 0 };
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

  UndeletePublication() {
    this.publicationSubsription = this.publicationService
      .UndeletePublication(this.publicationName.name)
      .subscribe((_publication) => {
        this.publication = _publication;
        console.log(_publication)
      });
      this.resetForm();
  }

  resetForm() {
    this.publicationName = { name: "" };
    this.publication = { id: 0, name: '', author: '', price: 0, pageCount: 0, description: '', genre: '', images: [] as string[], keyWords: '', quantity: 0 };
    this.UndeletePublicationForm.resetForm();
    this.submitted = false;
  }

  ngOnDestroy(): void {
    if (this.publicationSubsription) {
      this.publicationSubsription.unsubscribe();
    }
  }
}
