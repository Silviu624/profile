import { Component } from '@angular/core';
import { Experience } from '../../models/experience';

@Component({
  selector: 'app-experience',
  standalone: false,
  templateUrl: './experience.component.html',
  styleUrl: './experience.component.css'
})
export class ExperienceComponent {
  public experiences: Experience[] = [];

  constructor() {
    //read from db
    this.experiences.push(new Experience("Cognyte", "Software Developer", "Jul 2019",
      "Aug 2025", "Worked on various projects.", ["Angular", "TypeScript"]));
    this.experiences.push(new Experience("Company B", "Senior Developer", "Jan 2022",
      "Present", "Leading a team of developers.", ["React", "Node.js"]));
    this.experiences.push(new Experience("Company A", "Software Engineer", "Jan 2020",
      "Dec 2021", "Worked on various projects.", ["Angular", "TypeScript"]));
    this.experiences.push(new Experience("Company B", "Senior Developer", "Jan 2022",
      "Present", "Leading a team of developers.", ["React", "Node.js"]));
  }

}
