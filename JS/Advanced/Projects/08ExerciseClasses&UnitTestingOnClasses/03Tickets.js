function sortTickets(rawTickets, criterion){
    class Ticket{
    constructor(destinationName, pri, stat){
            this.destination = destinationName
            this. price = pri
            this.status = stat
        }
    }

    let tickets = [];

    for(let line of rawTickets){
        let rawTic = line.split('\|');
        tickets.push(new Ticket(rawTic[0], Number(rawTic[1]), rawTic[2]));
    }

    switch(criterion){
        case 'destination': 
        tickets.sort((a, b) => (a.destination > b.destination) ? 1 : (a.destination < b.destination) ? -1 : 0);
        break;
        case 'price': tickets = tickets.sort((a, b) => a.price - b.price); break;
        case 'status': tickets = tickets.sort((a, b) => (a.status > b.status) ? 1 : (a.status < b.status) ? -1 : 0); break;
    }

    return tickets;
}

console.log(sortTickets(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination'
));
console.log('----');
console.log(sortTickets(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'status'
));