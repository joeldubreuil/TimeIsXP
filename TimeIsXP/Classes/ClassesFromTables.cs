using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeIsXP.Classes
{
    public class EventChartXP
    {
        int idEventChartXP;
        int iPlayerNbTimeInEvent;
        int iTimeTotal;
        int iTimeGained;
        int iLossTimeLeap;
        int iVisualUpkeepPourcent;

        public EventChartXP(
            int _idEventChartXP,
            int _iPlayerNbTimeInEvent,
            int _iTimeTotal,
            int _iTimeGained,
            int _iLossTimeLeap,
            int _iVisualUpkeepPourcent
        )
        {
            idEventChartXP = _idEventChartXP;
            iPlayerNbTimeInEvent = _iPlayerNbTimeInEvent;
            iTimeTotal = _iTimeTotal;
            iTimeGained = _iTimeGained;
            iLossTimeLeap = _iLossTimeLeap;
            iVisualUpkeepPourcent = _iVisualUpkeepPourcent;
        }
    }

    public class Character
    {
        string sName;
        string sCharacterType;
        EventChartXP ecxpCharacter;
    }

    public class Skill
    {
        int idSkill;
        int idSkillCategory;
        string sName;
        string sDetail;
        int iMaxXP;

        List<SkillLevel> SkillLevels;

        public Skill()
        {
            //Load Skill Info
            //Load Skill Level Info
        }
    }

    public class SkillLevel
    {
        int idSkillLevel;
        int idSkill;
        string sSkillLevel;
        int iTotalTimeforLevel;
    }

    public class SkillCategory
    {
        int idSkillCategory;
        string sName;
    }

    public class CharacterSkill
    {
        int idCharacterSkill;
        int idCharacter;
        int idSkill;
        int iTimeInvested;
    }

    public class Event
    {
        int idEvent;
        DateTime dDate;
        string sEventName;
        double dEventCost;
    }

    public class CharacterEvent
    {
        int idCharacterEvent;
        int idCharacter;
        int idEvent;
        int idPayment;
    }

    public class Payment
    {
        int idPayment;
        int idCharacter;
        double dAmountPaid;
    }

    public class CharacterInvestment
    {
        int idCharacterInvestment;
        int idInvestmentAction;
        int iInvestmentAmount;
    }

    public class Investment
    {
        int idInvestment;
        string sType;
        string sInvestmentActionName;
        string sEffect;
    }

}