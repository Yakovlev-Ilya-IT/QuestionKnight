using UnityEngine;
using Zenject;

public class ConfigsInstaller : MonoInstaller
{
    [SerializeField, InjectOptional] private AdventureConfig _adventureConfig;
    [SerializeField, InjectOptional] private LevelConfig _levelConfig;
    [SerializeField, InjectOptional] private QuestionsCategorie _questionsCategorie;
    public override void InstallBindings()
    {
        BindExternal();
    }

    private void BindExternal()
    {
        Container.Bind<QuestionsCategorie>().FromInstance(_questionsCategorie);
        Container.Bind<AdventureConfig>().FromInstance(_adventureConfig);
        Container.Bind<LevelConfig>().FromInstance(_levelConfig);
        Container.Bind<EnemyWave>().FromInstance(_levelConfig.EnemyWave).AsSingle();
        Container.Bind<ConfigsHolder>().FromNew().AsSingle();   
    }
}
