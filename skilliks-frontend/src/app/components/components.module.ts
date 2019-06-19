import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ApiFeedbackComponent } from './api-feedback/api-feedback.component';
import { ApiFeedbackService } from './api-feedback/api-feedback.service';
import { FooterComponent } from './footer/footer.component';
import { NavbarComponent } from './navbar/navbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { StarRankingComponent } from './star-ranking/star-ranking.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    NgbModule
  ],
  declarations: [
    FooterComponent,
    NavbarComponent,
    SidebarComponent,
    ApiFeedbackComponent,
    StarRankingComponent
  ],
  exports: [
    FooterComponent,
    NavbarComponent,
    SidebarComponent,
    ApiFeedbackComponent,
    StarRankingComponent
  ],
  providers: [
    ApiFeedbackService
  ]
})
export class ComponentsModule { }
