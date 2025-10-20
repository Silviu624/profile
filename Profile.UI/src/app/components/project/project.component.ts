import { Component, OnInit } from '@angular/core';
import { Project } from '../../models/project';
import { ProjectService } from '../../services/project.service';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-project',
  standalone: false,
  templateUrl: './project.component.html',
  styleUrl: './project.component.css'
})
export class ProjectComponent implements OnInit {
  public projects: Project[] = [];
  public editMode: boolean = false;
  public editingIndex: number | null = null;
  public editBuffer: Project = null as any;

  constructor(private _projectService: ProjectService, private _authService: AuthService) { }

  ngOnInit(): void {
    this._projectService.getProjects().subscribe({
      next: projects => this.projects = projects,
      error: err => console.error('Error fetching projects', err)
    })
  }

  public isLoggedInFunction(): boolean {
    return this._authService.isLoggedIn();
  }

  public addNewProject() {
    this.projects.push(new Project("", "", "", "", ""));
    this.editingIndex = this.projects.length - 1;
    this.editBuffer = { ...this.projects[this.editingIndex] };
  }

  public isEditing(i: number): boolean {
    return this.editingIndex === i;
  }

  public toggleEdit(i: number, project: Project) {
    if (this.isEditing(i)) {
      const newProj = { ...project, ...this.editBuffer };

      if (this.editBuffer.id === "") {
        this.createProject(newProj);
      } else {
        this.saveProject(newProj);
      }

      this.projects[i] = newProj;
      this.editingIndex = null;
      this.editBuffer = null as any;
    } else {
      this.editingIndex = i;
      this.editBuffer = { ...project };
    }
  }

  public cancelEdit() {
    this.editingIndex = null;
    this.editBuffer = null as any;
  }

  public createProject(project: Project) {
    this._projectService.addProject(project).subscribe({
      next: createdProject => {
        console.log('Project created', createdProject);
      },
      error: err => console.error('Error creating project', err)
    });
  }

  public saveProject(project: Project) {
    this._projectService.updateProject(project.id, project).subscribe({
      next: updatedProject => console.log('Project updated', updatedProject),
      error: err => console.error('Error updating project', err)
    });
  }

  public delete(i: number, project: Project) {
    if (project.id === "") {
      this.projects.splice(i, 1);
      return;
    }
    this._projectService.deleteProject(project.id).subscribe({
      next: () => {
        this.projects = this.projects.filter(p => p.id !== project.id);
        console.log('Project deleted');
      },
      error: err => console.error('Error deleting project', err)
    });
  }
}
