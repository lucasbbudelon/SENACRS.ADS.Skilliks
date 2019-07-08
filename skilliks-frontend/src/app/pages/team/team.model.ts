import { User } from '../user/user.model';

export interface Team {
    image: string;
    name: string;
    description: string;
    users: User[];
    jobs: number;
}
