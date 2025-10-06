import { Component } from '@angular/core';
import { Project } from '../../models/project';

@Component({
  selector: 'app-project',
  standalone: false,
  templateUrl: './project.component.html',
  styleUrl: './project.component.css'
})
export class ProjectComponent {
  public projects: Project[] = [];
  constructor() {
    //read from db
    this.projects.push(new Project("Project A", "Description of Project A", "link to github", ["Angular", "TypeScript"]));
    this.projects.push(new Project("Project B", "Description of Project B", "link to github", ["React", "Node.js"]));
  }
}
