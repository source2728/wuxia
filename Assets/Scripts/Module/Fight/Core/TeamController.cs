using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TeamController
{
    protected List<CharacterController> m_CharacterList = new List<CharacterController>();
    public List<CharacterController> CharacterList
    {
        get { return m_CharacterList; }
    }

    public FightController.ETeamType TeamType;

    public CharacterController AddCharacter(int type, int id)
    {
        var character = new CharacterController();
        m_CharacterList.Add(character);
        return character;
    }

    public bool IsGameOver()
    {
        bool isAllDead = true;
        foreach (var characterController in CharacterList)
        {
            if (!characterController.IsDead())
            {
                isAllDead = false;
                break;
            }
        }
        return isAllDead;
    }
}
