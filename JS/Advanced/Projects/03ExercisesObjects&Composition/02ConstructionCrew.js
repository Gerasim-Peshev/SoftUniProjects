function workerModifier(worker){
    let result = {
        weight: worker.weight,
        experience: worker.experience,
        levelOfHydrated: worker.levelOfHydrated,
        dizziness: worker.dizziness
    };

    if(result.dizziness){
        result.levelOfHydrated+= 0.1 * result.weight * result.experience;
        result.dizziness = false;

        return result;
    } else{
        return result;
    }
}

console.log(workerModifier({ weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true }
));

console.log(workerModifier({ weight: 120,
    experience: 20,
    levelOfHydrated: 200,
    dizziness: true }
));

console.log(workerModifier({ weight: 95,
    experience: 3,
    levelOfHydrated: 0,
    dizziness: false }
));