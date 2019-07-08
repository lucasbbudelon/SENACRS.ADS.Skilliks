import { User } from '../user/user.model';
import { Team } from '../team/team.model';

export interface Job {
    name: string;
    description: string;
    level: Level;
    remuneration: number;
    minScore: number;
    team: Team;
    skills: any[];
}

export enum Level {
    trainee = 1,
    junior = 2,
    full = 3,
    senior = 4,
}
