export class Project {
    name: string = "";
    description: string = "";
    github: string = "";
    technologies: string[] = [];

    constructor(name: string, description: string, github: string, technologies: string[]) {
        this.name = name;
        this.description = description;
        this.github = github;
        this.technologies = technologies;
    }
}