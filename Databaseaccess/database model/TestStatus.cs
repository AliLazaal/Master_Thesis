using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace Testing_final
{
    public enum TestStatus

    {
        [MapValue("Unkwon")]
        Unkown,

        [MapValue("New")]
        New,

        [MapValue("Ticket(s) Open")]
        TicketOpen,

        [MapValue("All Tickets Closed")]
        AllTicketsClosed,

        [MapValue("Under Observation")]
        UnderObservation,

        [MapValue("In Re-Test Okay")]
        InReTestOkay,

        [MapValue("Re-Test Required")]
        ReTestRequired,

        [MapValue("Behaviour accepted")]
        BehaviourAccepted,

        [MapValue("In Consultation")]
        InConsultation,

        [MapValue("Skript fehler")]
        SkriptFehler,

        [MapValue("folge fehler")]
        FolgeFehler,

        
    }
}
