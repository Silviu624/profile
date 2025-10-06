import { Component } from '@angular/core';
import { Education } from '../../models/education';

@Component({
  selector: 'app-education',
  standalone: false,
  templateUrl: './education.component.html',
  styleUrl: './education.component.css'
})
export class EducationComponent {
  public educations: Education[] = [];
  constructor() {
    //read from db
    this.educations.push(new Education("B.Sc. in Computer Science", "University A", "2015", "2019", "Graduated with honors."));
    this.educations.push(new Education("M.Sc. in Software Engineering", "University B", "2020", "2022", "Specialized in web development."));
  }
}
