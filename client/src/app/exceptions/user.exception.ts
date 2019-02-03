export class UserNotFoundException extends Error {
    constructor(message) 
    {
        super(message);
        Object.setPrototypeOf(this, UserNotFoundException.prototype);
    }
}

export class UserCreationException extends Error {
    constructor(message) 
    {
        super(message);
        Object.setPrototypeOf(this, UserCreationException.prototype);
    }
}