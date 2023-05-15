using task2._2_sigma_.Presenters.Interfaces;
using task2._2_sigma_.Presenters;

IPresenter presenter = new MainMenuPresenter();
while (presenter != null)
{
    presenter.Show();
    presenter = presenter.Action();
}