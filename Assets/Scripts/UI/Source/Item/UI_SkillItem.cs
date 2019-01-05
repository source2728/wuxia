
namespace Main
{
    public partial class UI_SkillItem
    {
        public int SkillId { get; set; }

        public void OnRefresh(int skillId)
        {
            SkillId = skillId;
//            var info = CanBenDeploy.GetInfo(skillId);
//            m_LabelName.text = info.Name;
//            m_LabelDaofa.text = info.Daofa.ToString();
//            m_LabelWuli.text = info.Wuli.ToString();
//            m_LabelDiificult.text = "容易";
        }
    }
}

